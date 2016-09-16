﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL.BL;
using BL.DAL;
using BL.MODEL;
using App.BL;
using App.Model;

namespace VWMS.INVENTORY
{
    public partial class FrmInventoryProcess : Form
    {
        public FrmInventoryProcess()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ENTITY.FrmItems obj = new ENTITY.FrmItems(this);
            obj.ShowDialog();
        }

        public void LoadItemInfo(string id,string name,string qantity,string priceout) {

            lblID.Text = id;
            lblItemID.Text = id;
            lblItemName.Text = name;
            lblAvaiableQuantity.Text = qantity;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Helper.Confirmation(message:"This Process canot be rall back"))
                {
                    return;
                }
                if (!IsValidate())
                {
                    return;
                }
                var x = new InventoryInfomationDbService().Insert(new InventoryInfomation()
                {
                    ItemID = int.Parse(lblID.Text),
                    Qty = Convert.ToInt32(numericUpDown1.Value),
                    RegDate = DateTime.Now,
                    Type = (rdIn.Checked) ? 0 : 1,
                    UserName
                     = Properties.Settings.Default.EMAIL
                });
                if (x.State)
                {

                    LoadInfo();
                    MessageBox.Show("Sucessfully Inserted", "Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Insert is not Success", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (MyException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private List<InventoryInfomation> dtG = new List<InventoryInfomation>();
        private void LoadInfo()
        {
            dgvInventory.DataSource = dtG = (List<InventoryInfomation>)new InventoryInfomationDbService().Read().Content;
        }
        public bool IsValidate()
        {
            bool isOk = true;
            StringBuilder msg = new StringBuilder();

            if (lblID.Text=="0")
            {
                msg.Append("Item Id required \n");
                isOk = false;
            }
            if (isOk == false)
            {
                MessageBox.Show(msg.ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return isOk;

        }
        private void lblID_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Helper.Confirmation())
            {
                return;
            }
            var x = BL.BL.ItemsBL.UpdateInventory(new ItemModel
            {
                ID =Convert.ToInt32(lblUpId.Text),
                ItemID = Convert.ToInt32(lblID.Text),
                Qiantity = Convert.ToInt32(numericUpDown1.Text),
                InventoryType = types == 1 ? InventoryType.stockIn : InventoryType.stockOut,
                
               
            });
            if (x)
            {
                LoadInfo();
                MessageBox.Show("Sucessfully Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Update is not success", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int types = 0;
        private void rdIn_CheckedChanged(object sender, EventArgs e)
        {
            if (rdIn.Checked)
            {
                types = 1;
            }
         
        }

        private void rdOut_CheckedChanged(object sender, EventArgs e)
        {
            if (rdOut.Checked)
            {
                types = 2;
            }
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!Helper.Confirmation())
            {
                return;
            }
            var x = new InventoryInfomationDbService().Delete(int.Parse(lblUpId.Text));
            if (x.State)
            {
                LoadInfo();
                MessageBox.Show("Sucessfully Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Delete is not Success", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmInventoryProcess_Load(object sender, EventArgs e)
        {
            LoadInfo();

            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblItemName.Text = "Item Name";
            lblID.Text = "0";
            numericUpDown1.Value = 1;
            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            groupBox1.Enabled = true;

        }
        decimal quantity = 0;
        private void dgvInventory_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                btnInsert.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;

                lblUpId.Text = dgvInventory.Rows[e.RowIndex].Cells[0].Value.ToString();
                lblID.Text = dgvInventory.Rows[e.RowIndex].Cells[1].Value.ToString();
                quantity = numericUpDown1.Value = Convert.ToDecimal(dgvInventory.Rows[e.RowIndex].Cells[2].Value.ToString());
                groupBox1.Enabled = false;
                if (dgvInventory.Rows[e.RowIndex].Cells[3].Value.ToString() == "1")
                {
                    rdIn.Checked = true;
                    rdOut.Checked = false;
                }
                else
                {
                    rdOut.Checked = true;
                    rdIn.Checked = false;
                }
                lblItemName.Text = dgvInventory.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            catch { MessageBox.Show("invalied data"); }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ENTITY.FrmItems obj = new ENTITY.FrmItems(this);
            obj.ShowDialog();
        }

        public void rowColor()
        {

            for (int i = 0; i < dgvInventory.Rows.Count - 1; i++)
            {

                int val = Convert.ToInt32(dgvInventory.Rows[i].Cells["TYPE"].Value.ToString());

                if (val == 1)
                {
                    dgvInventory.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                }
                else
                {
                    dgvInventory.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }

            }
        }

        // print
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void chkFromDate_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        // search
        private void button3_Click(object sender, EventArgs e)
        {
            //INVENTORY_PROCESS.ID AS ID,ITEM_ID, QTY, TYPE,REG_DATE,USERNAME,TB_ITEMS.NAME AS NAME 
            string quary = "";
            bool IsFirstSelect = false;
            if (chkItem.Checked)
            {
                if (lblItemID.Text=="0")
                {
                    MessageBox.Show("please select item");return;
                }
                quary += " ITEM_ID = " + lblItemID.Text + "     and  ";
                IsFirstSelect = true;
            }

            if (chkStockMode.Checked)
            {
                quary += " TYPE = " + (cmbStockMode.SelectedIndex+1) + "     and  ";
                IsFirstSelect = true;
            }
 
            if (chkToDate.Checked)
            {
                quary += " REG_DATE between '" + dtFromDate.Value.ToShortDateString()+"' and '"+ dtToDate.Value.ToShortDateString() + "'     and  ";
                IsFirstSelect = true;
            }
            else if (chkFromDate.Checked)
            {
                quary += " REG_DATE between '" + dtFromDate.Value.ToShortDateString() + "' and '" + dtFromDate.Value.AddDays(1).ToShortDateString()+ "'     and  ";
                IsFirstSelect = true;
            }

            if (IsFirstSelect)
            {
                quary = "  where "+quary.Substring(0, quary.Length - 7);
            }
 
            dataGridView1.DataSource = ItemsBL.SelectSearchItems(quary).Content; 
        }

        private void chkToDate_CheckedChanged(object sender, EventArgs e)
        {
            chkFromDate.Checked = chkToDate.Checked;
        }
    }
}
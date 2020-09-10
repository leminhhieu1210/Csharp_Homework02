using QlySach;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace AppQlySach
{
    public partial class Form1 : Form
    {
        List<SachMoi> ds = new List<SachMoi>();

        public Form1()
        {
            InitializeComponent();
        }

        //Thêm mã sách từ các ô nhập dữ liệu
        private void buttAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMa.Text == "" || txtTen.Text == "" || txtTG.Text == "" || txtSoLuong.Text == "" || txtQr.Text == "")
                {
                    MessageBox.Show("Hãy nhập đầy đủ dữ liệu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    SachMoi ob = new SachMoi(txtMa.Text, txtTen.Text, txtTG.Text, int.Parse(txtSoLuong.Text), txtQr.Text);
                    if (checkMa(txtMa.Text) == true)
                    {
                        MessageBox.Show("Mã sách đã tồn tại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (checkQR(txtQr.Text) == true)
                    {
                        MessageBox.Show("Mã QR CODE đã tồn tại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        ds.Add(ob);
                        listBox1.Items.Add(txtMa.Text + "  " + txtTen.Text + "  " + txtTG.Text + "  " + int.Parse(txtSoLuong.Text) + "  " + txtQr.Text);
                        txtMa.Text = txtTen.Text = txtTG.Text = txtSoLuong.Text = txtQr.Text = "";
                    }
                }
            }
            catch
            {
                MessageBox.Show("Nhập sai kiểu dữ liệu. Hãy nhập lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //kiểm tra mã sách đã tồn tại chưa?
        bool checkMa(string s)
        {
            foreach (SachMoi ob in ds)
            {
                if (String.Compare(ob.MaSach, s) == 0)
                    return true;
            }
            return false;
        }

        //kiểm tra mã sách đã tồn tại chưa?
        bool checkQR(string s)
        {
            foreach (SachMoi ob in ds)
            {
                if (String.Compare(ob.QrCode, s) == 0)
                    return true;
            }
            return false;
        }

        //Tìm kiếm sách thông qua mã sách
        private void buttFind_Click(object sender, EventArgs e)
        {

            string fstring = Interaction.InputBox("Nhập mã sách:", "Xóa", "", 430, 400);
            if (string.IsNullOrWhiteSpace(fstring) == true) //nếu fstring (xâu lấy mã sách để tìm) rỗng --> Hiển thị lại các dữ liệu ban đầu
            {
                writeListBox1(ds);
                return;
            }

            int check = 0;
            foreach (SachMoi item in ds) //tìm mã sách
            {
                if (item.MaSach.CompareTo(fstring) == 0)
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add(item.MaSach + "  " + item.TenSach + "  " + item.TenTG + "  " + item.SoLuong.ToString() + "  " + item.QrCode);
                    check = 1;
                    break;
                }
            }
            if (check == 0)
            {
                MessageBox.Show("Không tìm thấy mã sách!", "Finded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listBox1.Items.Clear(); //nếu không tìm thấy thì hiển thị bảng trắng, không có dữ liệu.
            }
        }

        private void writeListBox1(List<SachMoi> book) //in dữ liệu vào ô Listbox1
        {
            listBox1.Items.Clear();
            foreach (SachMoi item in book)
            {
                listBox1.Items.Add(item.MaSach + "  " + item.TenSach + "  " + item.TenTG + "  " + item.SoLuong.ToString() + "  " + item.QrCode);
            }
        }

        private void buttDelete_Click(object sender, EventArgs e)
        {
            if (ds.Count > 0)
            {
                if (listBox1.SelectedIndex != -1)
                {
                    ds.RemoveAt(listBox1.SelectedIndex); //xoá dữ liệu tại ô Listbox1 khi người dùng click chọn vào.
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex); //xoá dữ liệu của List ds
                }
                else
                {
                    MessageBox.Show("Hãy chọn vào thuộc tính muốn xoá rồi nhấn Delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xoá!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

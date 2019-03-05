using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var comboList = new List<Models.ComboBoxItem>()
            {
                new Models.ComboBoxItem() {
                    DispValue = "aaa1",
                    ValueValue = "aaa",
                    List = new List<Models.DataTest>()
                    {
                        new Models.DataTest()
                        {
                            Column1 = "Column1-1",
                            Column2 = "Column1-2"
                        }
                    }
                },
                new Models.ComboBoxItem() {
                    DispValue = "bbb2",
                    ValueValue = "bbb",
                    List = new List<Models.DataTest>()
                    {
                        new Models.DataTest()
                        {
                            Column1 = "Column2-1",
                            Column2 = "Column2-2"
                        }
                    }
                }
            };
            comboBox1.DataSource = comboList;
            comboBox1.DisplayMember = "DispValue";
            comboBox1.ValueMember = "ValueValue";
            srComboBoxItemTextBox1.CustomAutoCompleteBox.DataSource = comboList;

            var dt = new DataTable();
            dt.Columns.Add("Column1");
            dt.Columns.Add("Column2");
            dt.Columns.Add("CheckCheck");
            dt.Columns.Add("RadioCheck");
            dt.Columns.Add("ComboItem");

            var row = dt.NewRow();
            row["Column1"] = "aaa1 disp";
            row["Column2"] = DateTime.Now;
            row["CheckCheck"] = 10;
            row["RadioCheck"] = true;
            row["ComboItem"] = "aaa";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Column1"] = "aaa2 disp";
            row["Column2"] = new DateTime(2010, 10, 12);
            row["CheckCheck"] = 0;
            row["RadioCheck"] = false;
            row["ComboItem"] = "bbb";
            dt.Rows.Add(row);

            srStringTextBox1.CustomAutoCompleteBox.DataSource = dt;



            var list = new List<Models.CompleteTestListItem>();
            list.Add(new Models.CompleteTestListItem()
            {
                Column1 = "aaa1 disp",
                Column2 = DateTime.Now,
                CheckCheck = 10,
                RadioCheck = true,
                ComboItem = "aaa"
            });

            list.Add(new Models.CompleteTestListItem()
            {
                Column1 = "aaa2 disp",
                Column2 = new DateTime(2010, 10, 12),
                CheckCheck = 0,
                RadioCheck = false,
                ComboItem = "bbb"
            });

            completeTestListItemTextBox1.CustomAutoCompleteBox.DataSource = list;



            var efList = new List<Models.EfSample1>();
            var efSample1 = new Models.EfSample1()
            {
                Sample1Data = "Sample1Data"
            };
            try
            {
                var efSample3 = new Models.EfSample3()
                {
                    Sample3Data = "Data3"
                };
                efSample1.EfSample2.Add(new Models.EfSample2()
                {
                    Sample2Data = "Sample2Data"
                });
                efSample1.EfSample2.Local[0].EfSample3.Add(efSample3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            efList.Add(efSample1);

            efSample1TextBox1.CustomAutoCompleteBox.DataSource = efList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //niigataTextBox1.Text = "aaa2 disp";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal a = 100 ^ 100;

            int b;
            b = (int)a;
            Console.WriteLine(b);

            short c;
            c = (short)b;
            Console.WriteLine(c);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            completeTestListItemTextBox1.MapFields();
        }
    }
}

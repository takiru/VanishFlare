using Sample.DbContexts;
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
using System.Data.Entity;
using Sample.Entities;

namespace Sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            orderHistoriesDgv.AutoGenerateColumns = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var comboList = new List<MapFieldControls.ListItem>()
            {
                new MapFieldControls.ListItem() {
                    DispValue = "aaa1",
                    ValueValue = "aaa",
                    List = new List<MapFieldControls.DataTest>()
                    {
                        new MapFieldControls.DataTest()
                        {
                            Column1 = "Column1-1",
                            Column2 = "Column1-2"
                        },
                        new MapFieldControls.DataTest()
                        {
                            Column1 = "Column1-3",
                            Column2 = "Column1-4"
                        }
                    }
                },
                new MapFieldControls.ListItem() {
                    DispValue = "bbb2",
                    ValueValue = "bbb",
                    List = new List<MapFieldControls.DataTest>()
                    {
                        new MapFieldControls.DataTest()
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



            var list = new List<MapFieldControls.SimpleItem>();
            list.Add(new MapFieldControls.SimpleItem()
            {
                Column1 = "aaa1 disp",
                Column2 = DateTime.Now,
                CheckCheck = 10,
                RadioCheck = true,
                ComboItem = "aaa"
            });

            list.Add(new MapFieldControls.SimpleItem()
            {
                Column1 = "aaa2 disp",
                Column2 = new DateTime(2010, 10, 12),
                CheckCheck = 0,
                RadioCheck = false,
                ComboItem = "bbb"
            });

            completeTestListItemTextBox1.CustomAutoCompleteBox.DataSource = list;
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            completeTestListItemTextBox1.Text = "aaa2 disp";
            //completeTestListItemTextBox1.MapFields();
        }

        #region EntityFramework

        private void userIdText_CandidateBoxOpening(object sender, EventArgs e)
        {
            userIdText.CustomAutoCompleteBox.DataSource = FindUserCandidate();
        }

        private void userIdItemText_CandidateBoxOpening(object sender, EventArgs e)
        {
            userIdItemText.CustomAutoCompleteBox.DataSource = FindUserCandidate();
        }

        private void remapSimpleButton_Click(object sender, EventArgs e)
        {
            userIdText.MapFields();
        }

        private void remapReSearchButton_Click(object sender, EventArgs e)
        {
            userIdText.CustomAutoCompleteBox.DataSource = FindUserCandidate();
            userIdText.CustomAutoCompleteBox.DecideItemForText(userIdText.Text);
        }

        private List<UserInfo> FindUserCandidate()
        {
            var context = new DefaultDbContext();
            return context.UserInfos.Include(u => u.OrderHistories).ToList();
        }

        #endregion
    }
}

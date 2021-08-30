using Business_Logic_Layer;
using Entities1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LayeredArchitectureWithCodeFirst
{
	public partial class Form1 : Form
	{
        private PostBusiness _postBusiness;
        private   ApiBusiness _apiBusiness;
		public Form1()
		{
			InitializeComponent();
            _postBusiness = new PostBusiness();
            _apiBusiness = new ApiBusiness();
		}

        private async void button1_Click(object sender, EventArgs e)
        {
            var postList = await _apiBusiness.GetAllPost();
            dataGridView1.DataSource = postList;

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var postList = await _apiBusiness.GetAllPost();
            foreach (var post in postList)
            {
                _postBusiness.Add(post);
            }
        }
    }
}

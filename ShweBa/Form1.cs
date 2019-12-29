using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace ShweBa
{
    public partial class Form1 : Form
    {

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "mi3etz3kVqs9KgEd9o73c6x8LRAhxFmBwYGh10GC",
            BasePath = "https://thethtar-30264.firebaseio.com/"
        };

        IFirebaseClient client;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void CheckAndResetWindowSize()
        {
            if (Console.WindowHeight != 900 || Console.WindowWidth != 700)
            {
                Console.SetWindowSize(940, 700);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var datas = new Data
            {
                topic=title.Text,
                summary=proposal.Text,
                code=code.Text,
                date=date.Text,
                department=department.Text,
                mtown=city.Text

            };
            SetResponse response = await client.SetTaskAsync("Department/" + city.Text +"/"+ code.Text,datas);
            Data result = response.ResultAs<Data>();

            MessageBox.Show("Showing" + result.topic);
        }
    }
}

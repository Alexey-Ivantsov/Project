using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Shared;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Builders;
using System.Collections;
using MongoDB.Driver.Linq;

namespace Wpf_with_MongoDB
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            server = Client.GetServer();
            server.Connect();
            DB = server.GetDatabase("Book");
            Collection = DB.GetCollection<info>("History");
            //bindgrid();

            var list = Collection.AsQueryable().Select(x => new Person()
            {
                FirstName = x.firstname,
                LastName = x.lastname,
                Age = x.age,
                Id = x.info_id

            });
            DataContext = new ApplicationViewModel(list);
        }

        public class info
        {
            [BsonId]
            public MongoDB.Bson.BsonObjectId Id { get; set; }
            public int info_id { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public int age { get; set; }
        }
        MongoDatabase DB;
        MongoClient Client = new MongoClient("mongodb://localhost");
        MongoCollection<info> Collection;
        MongoServer server;
        info _inf;
        private void UpdateDB(object sender, RoutedEventArgs e)
        {
            _inf = new info { firstname = FirstNamBox.Text, lastname = LastNameBox.Text, age = Convert.ToInt16(AgeBox.Text), info_id = Convert.ToInt16(IdBox.Text) };
            infogrid.Focusable = false;
            _inf.firstname = FirstNamBox.Text;
            _inf.lastname = LastNameBox.Text;
            _inf.age = Convert.ToInt16(AgeBox.Text);
            updateInfo(_inf);
        }
        public void updateInfo(info _info)
        {
            IMongoQuery query = Query.EQ("info_id", _inf.info_id);
            IMongoUpdate update = Update
                .Set("firstname", _info.firstname)
               .Set("lastname", _info.lastname)
               .Set("age", _info.age);
            Collection.Update(query, update);

        }

        private void DeleteDb(object sender, RoutedEventArgs e)
        {
            _inf = new info { info_id = Convert.ToInt16(IdBox.Text) };
            IMongoQuery query = Query.EQ("info_id", _inf.info_id);
            Collection.Remove(query);
            var list = Collection.AsQueryable().Select(x => new Person()
            {
                FirstName = x.firstname,
                LastName = x.lastname,
                Age = x.age,
                Id = x.info_id

            });
            DataContext = new ApplicationViewModel(list);
        }

        /* public void reversBind(info _info)
         {
             textBox1.Text = _info.firstname;
             textBox2.Text = _info.lastname;
             textBox3.Text = _info.age.ToString();
             textBox4.Text = _info.info_id.ToString();
         }

         /*private void ConnectMongodb_Click(object sender, RoutedEventArgs e)
         {
             _inf = new info { info_id = (int)DB.GetCollection("History").Count() + 1, firstname = textBox1.Text, lastname = textBox2.Text, age = Convert.ToInt16(textBox3.Text) };
             addinfo(_inf);
             bindgrid();
         }



         public void addinfo(info _info)
         {

             _info.Id = ObjectId.GenerateNewId();
             Collection.Insert(_info);
         }

        public void bindgrid()
        {
           infogrid.DataContext = Collection.FindAll();
           infogrid.ItemsSource = Collection.FindAll();
        }

        
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            _inf = new info { info_id = Convert.ToInt16(textBox4.Text), firstname = textBox1.Text, lastname = textBox2.Text, age = Convert.ToInt16(textBox3.Text) };
            infogrid.Focusable = false;
            _inf.info_id = Convert.ToInt16(textBox4.Text);
            _inf.firstname = textBox1.Text;
            _inf.lastname = textBox2.Text;
            _inf.age = Convert.ToInt16(textBox3.Text);
            updateInfo(_inf);
            bindgrid();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox1.Focus();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            _inf = new info { info_id = Convert.ToInt16(textBox4.Text) };
            _inf.info_id = Convert.ToInt16(textBox4.Text);
            del(_inf);
            bindgrid();
        }

        private void infogrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {

            }
        }

        public void del(info _info)
        {

        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }*/
    }
}

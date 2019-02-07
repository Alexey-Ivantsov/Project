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

namespace WpfDB
{

    public partial class MainWindow : Window
    {

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
        public MainWindow()
        {
            InitializeComponent();
            //const string uri = "mongodb://localhost:27017/Book";
            server = Client.GetServer();
            server.Connect();
            DB = server.GetDatabase("Book");
            Collection = DB.GetCollection<info>("History");
            bindgrid();
        }
        public void reversBind(info _info)
        {

            textBox1.Text = _info.firstname;
            textBox2.Text = _info.lastname;
            textBox3.Text = _info.age.ToString();
            textBox4.Text = _info.info_id.ToString();

        }
        public int Getinfo(int id)
        {
            IMongoQuery query = Query.EQ("info_id", id);
            // IMongoQuery query = Query.EQ("info_id", id);
            //return _infos.Find(query).FirstOrDefault();
            return 54;

        }

        private void ConnectMongodb_Click(object sender, RoutedEventArgs e)
        {
            // insert the record in to the mydb info collaction<table> 
            _inf = new info { info_id = (int)DB.GetCollection("History").Count() + 1, firstname = textBox1.Text, lastname = textBox2.Text, age = Convert.ToInt16(textBox3.Text) };
            addinfo(_inf);
            bindgrid();
        }

        public void upd(IMongoQuery q, IMongoUpdate u)
        {

            Collection.Update(q, u);
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

        private void infogrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {

            }
        }

        public void updateInfo(info _info)
        {
            IMongoQuery query = Query.EQ("info_id", _info.info_id);
            IMongoUpdate update = Update
                .Set("info_id", _info.info_id)
                .Set("firstname", _info.firstname)

               .Set("lastname", _info.lastname)
               .Set("age", _info.age);
            upd(query, update);
            // SafeModeResult result = _inf.update(query, update);
            // return result.UpdatedExisting;

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

        public void del(info _info)
        {
            IMongoQuery query = Query.EQ("info_id", _info.info_id);
            Collection.Remove(query);
        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

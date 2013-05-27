using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.IO;
using System.Windows.Interop;
using System.Windows;
using System.Drawing.Imaging;
using Microsoft.Win32;
using System.Windows.Input;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace WPF_Viewer
{
    public class MVVM : INotifyPropertyChanged
    {
        private EDM_modelContainer db;
        private int windowHeight, windowWidth;

        private Dictionary<Relation, System.Windows.Point[]> relationsColl;
        private Dictionary<User, System.Windows.Point> usersColl;

        private byte[] ImgToDB(string address)
        {
            Stream gifstream = new FileStream(address, FileMode.Open, FileAccess.Read, FileShare.Read);
            Bitmap _bitmap = new Bitmap(gifstream);

            MemoryStream mstream = new MemoryStream();
            _bitmap.Save(mstream, ImageFormat.Gif);
            //_bitmap.Save(mstream, ImageFormat.Jpeg);
            return mstream.ToArray();
        }

        private void FillDB()
        {
            db.UserSet.Local.Add(new User { 
                    BirthDate = new DateTime(1992, 12,29), 
                    FirstName = "Olga", 
                    LastName = "Ivanova", 
                    Id = Guid.NewGuid(), Email = "email1",
                    Photo = ImgToDB("D:/Documents/Programming/DB_Practicum/WPF_Viewer/anime.jpg")
                });

//            db.SaveChanges();

            db.UserSet.Local.Add(new User
            {
                BirthDate = new DateTime(1988, 05, 14),
                FirstName = "Ivan",
                LastName = "Petrov",
                Id = Guid.NewGuid(),
                Email = "email2",
                Photo = ImgToDB("D:/Documents/Programming/DB_Practicum/WPF_Viewer/a2.gif")
            });

//            db.SaveChanges();

            db.UserSet.Local.Add(new User
            {
                BirthDate = new DateTime(1975, 10, 15),
                FirstName = "Anna",
                LastName = "Ivanova",
                Id = Guid.NewGuid(),
                Email = "email3"//,
                //Photo = ImgToDB("a3.gif")
            });

            db.RelationSet.Local.Add(new Relation 
            { 
                Id = Guid.NewGuid(), 
                Type = "Friends", 
                User1 = db.UserSet.Local.ElementAt(0), 
                User2 = db.UserSet.Local.ElementAt(1) 
            });

            db.RelationSet.Local.Add(new Relation
            {
                Id = Guid.NewGuid(),
                Type = "Relatives",
                User1 = db.UserSet.Local.ElementAt(0),
                User2 = db.UserSet.Local.ElementAt(2)
            });
        }

        public MVVM()
        { 
            db = new EDM_modelContainer();
            db.RelationSet.Load();
            db.UserSet.Load();
            //FillDB(); //once
            //db.SaveChanges();
            
            windowWidth = 800;
            windowHeight = 400;
            usersColl = new Dictionary<User, System.Windows.Point>();
            
            UpdateUsersColl();
            UpdateRelationsColl();
        }

        public Dictionary<User, System.Windows.Point> UsersColl { get { return usersColl; } set { usersColl = value; } }
        public Dictionary<Relation, System.Windows.Point[]> RelationsColl { get { return relationsColl; } }

        public User[] SimpleUserC { get
            {
                Collection<User> tmp = new Collection<User>();
                foreach (var user in usersColl.Keys) { tmp.Add(user); }
                return tmp.ToArray();
        } }

        public System.Windows.Point[] SimpleUserP
        {
            get
            {
                Collection<System.Windows.Point> tmp = new Collection<System.Windows.Point>();
                foreach (var user in usersColl.Values) { tmp.Add(user); }
                return tmp.ToArray();
            }
        }

        //public System.Windows.Point[][] SimpleRelP
        //{
        //    get
        //    {
        //        Collection<System.Windows.Point[]> tmp = new Collection<System.Windows.Point[]>();
        //        foreach (var rel in relationsColl.Values) { tmp.Add(rel); }
        //        return tmp.ToArray();
        //    }
        //}

        public Relation[] SimpleRelC
        {
            get
            {
                Collection<Relation> tmp = new Collection<Relation>();
                foreach (var rel in relationsColl.Keys) { tmp.Add(rel); }
                return tmp.ToArray();
            }
        }



        public void UpdateUsersColl()
        {
            usersColl = new Dictionary<User,System.Windows.Point>();
            UsersColl = new Dictionary<User, System.Windows.Point>();
            double angle = 0;
            double _incrementalAngularSpace = (360.0 / db.UserSet.Local.Count) * (Math.PI / 180);
            int radius_x = (int)(WSW*0.4);
            int radius_y = (int)(WSH*0.4);
            foreach(User u in db.UserSet.Local)
            {
                usersColl.Add(u, 
                    new System.Windows.Point((int)(WSW/2 + radius_x*Math.Cos(angle)),(int)(WSH/2 + radius_y*Math.Sin(angle))));
                angle += _incrementalAngularSpace;
            }
            NotifyPropertyChanged("UsersColl");
        }

        /// <summary>
        /// use this after UpdateUsersColl()
        /// </summary>
        public void UpdateRelationsColl()
        {
            relationsColl = new Dictionary<Relation, System.Windows.Point[]>();
            foreach (Relation r in db.RelationSet.Local)
            { 
                System.Windows.Point[] value = new System.Windows.Point[2];
                if (usersColl[r.User1].X <= usersColl[r.User2].X)
                {
                    value[0].X = usersColl[r.User1].X + 200;
                    value[1].X = usersColl[r.User2].X;
                    if (usersColl[r.User1].Y <= usersColl[r.User2].Y)
                    {
                        value[0].Y = usersColl[r.User1].Y + 100;
                        value[1].Y = usersColl[r.User2].Y;
                    }
                    else 
                    {
                        value[0].Y = usersColl[r.User1].Y;
                        value[1].Y = usersColl[r.User2].Y + 100;
                    }
                }
                else
                {
                    value[0].X = usersColl[r.User2].X + 200;
                    value[1].X = usersColl[r.User1].X;
                    if (usersColl[r.User1].Y <= usersColl[r.User2].Y)
                    {
                        value[0].Y = usersColl[r.User2].Y;
                        value[1].Y = usersColl[r.User1].Y + 100;
                    }
                    else
                    {
                        value[0].Y = usersColl[r.User2].Y + 100;
                        value[1].Y = usersColl[r.User1].Y;
                    }
                }

                relationsColl.Add(r, value);
            }
            NotifyPropertyChanged("RelationsColl");
        }

        public void UpdateCoords()
        {
            double _incrementalAngularSpace = (360.0 / db.UserSet.Local.Count) * (Math.PI / 180);
            int radius_x = (int)(WSW * 0.4);
            int radius_y = (int)(WSH * 0.4);
            double angle = 0;

            foreach (KeyValuePair<User, System.Windows.Point> elem in usersColl)
            {
               usersColl[elem.Key] = new System.Windows.Point(
                        (int)(WSW / 2 + radius_x * Math.Cos(angle)),
                        (int)(WSH / 2 + radius_y * Math.Sin(angle))
                        );
            }

            NotifyPropertyChanged("UsersColl");
            NotifyPropertyChanged("RelationsColl");
        }

        public void Window_StateChanged()
        {
            UpdateCoords();
        }

        public int WSH { get { return windowHeight; } set { windowHeight = value; } }
        public int WSW { get { return windowWidth; } set { windowWidth = value; } }

        //public DbSet<User> Users { get { return db.UserSet; } }
        //public DbSet<Relation> Relations { get { return db.RelationSet; } }

        private Relation newRel;
        public Relation NewRel { get { return newRel; } set { newRel = value; } }
        public void AddRel_Click()
        {
            newRel = new Relation();
        }

        private User newUser;
        private Window_AddUser window_add;
        public User NewUser { get { return newUser;} set { newUser = value; } }
        public void AddUser_Click()
        {
            newUser = new User();
            //newUser = db.UserSet.Local[0];

            CanAddUser = false;
            AddUserCommand = new MyCommand(param => this.AddUser(), param => this.CanAddUser);

            window_add = new Window_AddUser();
            window_add.Show();
        }

        public void LoadImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog { Title = "Select image", Filter = "Image files (*.gif)|*.gif" };
            if (openFileDialog.ShowDialog() != true)
                return;

            string SelectedImage = openFileDialog.FileName;
            System.Windows.Controls.Image im = new System.Windows.Controls.Image();
            im.Source = new BitmapImage(new Uri(SelectedImage));
            window_add.img.Source = im.Source;

            newUser.Photo = ImgToDB(SelectedImage);

            if (newUser.Photo != null && newUser.FirstName != "" && newUser.LastName != "" && newUser.BirthDate != null && newUser.Email != "")
                CanAddUser = true;
        }

        private MyCommand AddUserCommand;

        private void AddUser()
        { }

        private bool CanAddUser;

        public ICommand AddUser_comm { get { return AddUserCommand; } }

        public void IfAllFilled()
        {
            if (newUser.Photo != null && newUser.FirstName != "" && newUser.FirstName != null
                && newUser.LastName != "" && newUser.LastName != null
                && newUser.BirthDate != null && newUser.Email != "" && newUser.Email != null)
                CanAddUser = true;
            else
                CanAddUser = false;
        }

        public void AddUserToDB()
        {
            newUser.Id = Guid.NewGuid();
            db.UserSet.Local.Add(newUser);

            db.RelationSet.Local.Add(new Relation { Id = Guid.NewGuid(), Type = "Colleagues", User1 = db.UserSet.Local[0], User2 = db.UserSet.Local.Last() });

            db.SaveChanges();
            newUser = new User();
            window_add.Close();
            UpdateUsersColl();
            //UpdateCoords();
            UpdateRelationsColl();
//            App.Current.MainWindow.Show();
            NotifyPropertyChanged("UsersColl");
            NotifyPropertyChanged("RelationsColl");
        }

        public void SaveUserXML(Guid userId)
        {
            const string S = "http://cs.msu.su/mph/dotnet4/snw";

            Microsoft.Win32.SaveFileDialog SFD = new Microsoft.Win32.SaveFileDialog();
            SFD.AddExtension = true;
            SFD.Filter = "xml files (*.xml)|*.xml";
            SFD.FilterIndex = 1;

            if (SFD.ShowDialog() == true)
            {
                if (!File.Exists(SFD.FileName))
                {
                    Stream stream = File.Create(SFD.FileName);
                    stream.Close();
                }

                object[] qparam = {userId};
                User u = db.UserSet.Find(qparam);

                XmlWriterSettings xws = new XmlWriterSettings();
                xws.OmitXmlDeclaration = false;
                xws.Indent = true;

                var writer = XmlWriter.Create(SFD.FileName, xws);
                var xelem = new XElement(XName.Get("User", S));
                xelem.SetAttributeValue("FirstName", u.FirstName);
                xelem.SetAttributeValue("LastName", u.LastName);
                xelem.SetAttributeValue("BirthDate", u.BirthDate);
                xelem.SetAttributeValue("Email", u.Email);
                xelem.SetAttributeValue("Id", u.Id);
                if (u.Photo != null)
                    xelem.SetAttributeValue("Photo", Convert.ToBase64String(u.Photo));

                XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "no"), xelem);
                doc.Declaration.Standalone = null;

                var query1 = from r in db.RelationSet
                             where r.UserId1 == userId || r.UserId2 == userId
                             select r;
                foreach (Relation r in query1)
                {
                    var rXelem = new XElement(XName.Get("Relation"), S);
                    rXelem.SetAttributeValue("Id", r.Id);
                    rXelem.SetAttributeValue("Type", r.Type);
                    rXelem.SetAttributeValue("UserId1", r.UserId1);
                    rXelem.SetAttributeValue("UserId2", r.UserId2);
                    doc.Root.Add(rXelem);
                }
                    //User _u;
                    //if (r.UserId1 == userId)
                    //    _u = r.User2;
                    //else _u = r.User1;

                    //var uXelem = new XElement(XName.Get("User"), S);
                    //uXelem.SetAttributeValue("Id", _u.Id);
                    //uXelem.SetAttributeValue("FirstName", _u.FirstName);
                    //uXelem.SetAttributeValue("LastName", _u.LastName);
                    //uXelem.SetAttributeValue("BirthDate", _u.BirthDate);
                    //uXelem.SetAttributeValue("Email", _u.Email);
                    //if (_u.Photo != null)
                    //    uXelem.SetAttributeValue("Photo", _u.Photo);
                    //doc.Root.Add(uXelem);

                doc.Save(writer);
                writer.Flush();
                writer.Close();

                try
                {
                    var schemas = new XmlSchemaSet();
                    schemas.Add(null, "XMLSchema1.xsd");

                    var reader = XmlReader.Create(SFD.FileName,
                    new XmlReaderSettings()
                    {
                        ValidationType = ValidationType.Schema,
                        Schemas = schemas
                    });

                    XDocument temp = XDocument.Load(reader);
                }
                catch
                {
                    MessageBox.Show("Файл сохранен, но не соответствует шаблону.", "Предупреждение!");
                    return;
                }

                MessageBox.Show("Файл сохранен.", "Успешно");
            }
        }

        public void LoadUserXML()
        {
            Microsoft.Win32.OpenFileDialog OFD = new Microsoft.Win32.OpenFileDialog();
            OFD.Filter = "xml files (*.xml)|*.xml";
            OFD.FilterIndex = 1;
            if (OFD.ShowDialog() == true)
            {
                var schemas = new XmlSchemaSet();
                schemas.Add(null, "XMLSchema1.xsd");

                var reader = XmlReader.Create(OFD.FileName,
                new XmlReaderSettings()
                {
                    ValidationType = ValidationType.Schema,
                    Schemas = schemas
                });

                XDocument newUser = new XDocument();
                try
                {
                    newUser = XDocument.Load(reader);
                }
                catch
                {
                    MessageBox.Show("Файл не соответствует шаблону.", "Ошибка!");
                    return;
                }

                var ns = new XmlNamespaceManager(reader.NameTable);
                const string S = "http://cs.msu.su/mph/dotnet4/snw";
                ns.AddNamespace("a", S);

                //MessageBox.Show(newUser.Root.Attribute("Id").Value);
                Guid newUserId = new Guid(newUser.Root.Attribute("Id").Value);
                if (db.UserSet.Find(newUserId) != null)
                {
                    MessageBox.Show("Такой пользователь уже существует", "Ошибка!");
                    return;
                }

                byte[] bytes = new byte[newUser.Root.Attribute("Photo").Value.Length * sizeof(char)];
                System.Buffer.BlockCopy(newUser.Root.Attribute("Photo").Value.ToCharArray(), 0, bytes, 0, bytes.Length);

                db.UserSet.Add(new User
                {
                    Id = newUserId,
                    FirstName = newUser.Root.Attribute("FirstName").Value,
                    LastName = newUser.Root.Attribute("LastName").Value,
                    BirthDate = Convert.ToDateTime(newUser.Root.Attribute("BirthDate").Value),
                    Email = newUser.Root.Attribute("Email").Value,
                    Photo = Convert.FromBase64String(newUser.Root.Attribute("Photo").Value)
                });

                db.SaveChanges();

                foreach (var rel in newUser.Root.Elements("Relation"))
                {
                    try
                    {
                        db.RelationSet.Add(new Relation
                        {
                            Id = new Guid(rel.Attribute("Id").Value),
                            Type = rel.Attribute("Type").Value,
                            UserId1 = new Guid(rel.Attribute("UserId1").Value),
                            UserId2 = new Guid(rel.Attribute("UserId2").Value),
                            User1 = db.UserSet.Find(new Guid(rel.Attribute("UserId1").Value)),
                            User2 = db.UserSet.Find(new Guid(rel.Attribute("UserId2").Value))
                        });
                    }
                    catch {
                        MessageBox.Show("Несоответствие данных", "Ошибка!");
                    }
                }

                db.SaveChanges();
                reader.Close();

                MessageBox.Show("Успешно");
                //MainWindow mw = new MainWindow();
                
                //MVVM MVVM_obj = new MVVM();
                //this.NavigationService.Navigate(MVVM_obj);
                NotifyPropertyChanged("UsersColl");
                NotifyPropertyChanged("RelationsColl");
            }
        }

        public void DeleteUser(Guid userId)
        {
            var query1 = from r in db.RelationSet
                         where r.UserId1 == userId || r.UserId2 == userId
                         select r;
            foreach (Relation r in query1)
            {
                db.RelationSet.Local.Remove(r);
            }

            db.UserSet.Local.Remove(db.UserSet.Find(userId));

            db.SaveChanges();

            UpdateUsersColl();
            UpdateRelationsColl();

            NotifyPropertyChanged("UsersColl");
            NotifyPropertyChanged("RelationsColl");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }  
    }

    class MyCommand : ICommand
    {
        Action<object> _execute;
        Predicate<object> _canExecute;

        protected internal object sender;

        public MyCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            sender = parameter;
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}

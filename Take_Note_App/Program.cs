namespace Take_Note_App
{
    public class Note
    {
        public int Id { get;  set; }
        public string Title { get;  set; }
        public string Description { get; set; }
        public DateTime Date { get;  set; }
    }
    public class Noteapp
    {
        List<Note> notes;
        public int count = 0;

        public Noteapp()
        {
            DateTime date= DateTime.Now;
            notes = new List<Note>()
            {

                new Note{Id=1, Title="Meeting", Description="Meeting with Client @ 9AM",Date=date},
                new Note{Id=2, Title="Pay Bills", Description="Pay Electricity Bills", Date=date}
                

            };
        }
        public void Addnote(Note note)
        {
            notes.Add(note);
        }
        public List<Note> Getnotes()
        {
            return notes;
            
        }
        public Note Getnote(int id)
        {
            foreach (Note n in notes)
            {
                if (n.Id == id)
                    return n;
            }
            return null;
        }
        public bool Deletenote(int id)
        {
            foreach (Note n in notes)
            {
                if (n.Id == id)
                {
                    notes.Remove(n);
                    return true;
                }
            }
            return false;
        }
        public bool Updatenote(int id)
        {
            foreach (Note n in notes)
            {
                if (n.Id == id)
                {
                    Console.WriteLine("Enter Title");
                    string title = Console.ReadLine();
                    Console.WriteLine("Enter Description");
                    string desc = Console.ReadLine();
                    n.Title = title;
                    n.Description = desc;
                    return true;
                }
            }
            return false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Noteapp noteapp = new Noteapp();
            string ans = "";
            do
            {
                Console.WriteLine("Welcome to Take Note App");
                Console.WriteLine("1. Create Note");
                Console.WriteLine("2. View Note");
                Console.WriteLine("3. View All Notes");
                Console.WriteLine("4. Update Note");
                Console.WriteLine("5. Delete Note");

                int choice = Convert.ToInt16(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter Title");
                            string title = Console.ReadLine();
                            Console.WriteLine("Enter Description");
                            string desc = Console.ReadLine();
                            DateTime date = DateTime.Now;
                            Random rnd = new Random();
                            int randomNum = rnd.Next(1, 100);
                            int username = randomNum;
                            int id = username;
                            Random random = new Random();
                            noteapp.Addnote(new Note() { Id = id, Title = title, Description = desc , Date=date});
                            break;

                        }
                    case 2:
                        {
                            Console.WriteLine("Id");
                            int id = Convert.ToInt16(Console.ReadLine());
                            Note? p = noteapp.Getnote(id);
                            if (p == null)
                            {
                                Console.WriteLine("Note with specified id does not exists");
                            }
                            else
                            {
                                Console.WriteLine($"{p.Id}\t{p.Title}\t{p.Description}\t{p.Date}");
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("ID\tTitle\t\t\tDescription\t\tDate");
                            foreach (var p in noteapp.Getnotes())
                            {
                                
                                Console.WriteLine($"{p.Id}\t{p.Title}\t\t{p.Description}\t{p.Date}");
                                Console.WriteLine("");
                                
                                
                            }
                            
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter Note ID");
                            int id = Convert.ToInt16(Console.ReadLine());
                            if (noteapp.Updatenote(id))
                            {
                                Console.WriteLine("Note details Updated Successfully!!");
                            }
                            else
                            {
                                Console.WriteLine("Note with specified id does not exist");
                            }
                            break;

                        }
                    case 5:
                        {
                            Console.WriteLine("Enter Note Id");
                            int id = Convert.ToInt16(Console.ReadLine());
                            if (noteapp.Deletenote(id))
                            {
                                Console.WriteLine("note Deleted Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Note with specified id does not exist");
                            }
                            break;
                        }
                }
                Console.WriteLine("Do you wish to continue? [y/n] ");
                ans = Console.ReadLine();
            } while (ans.ToLower() == "y");
        }
    }
}
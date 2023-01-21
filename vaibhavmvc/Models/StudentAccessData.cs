namespace DAL;
using BOL;
using MySql.Data.MySqlClient;

public static class StudentAccessData
{
    public static string constring=@"server=localhost;port=3306;user=root;password=root123;database=demo2";

    public static List<Student> GetAllStudent()
    {
        List<Student> allstud=new List<Student>();

        MySqlConnection con=new MySqlConnection(constring);

        try{
            con.Open();
            string query="select * from student";

            MySqlCommand cmd=new MySqlCommand(query,con);
            MySqlDataReader reader=cmd.ExecuteReader();

            while(reader.Read())
            {
                Student stud=new Student{
                    id=int.Parse(reader["id"].ToString()),
                    name=reader["name"].ToString(),
                    place=reader["place"].ToString()
                };
                allstud.Add(stud);
            }


        }catch(Exception e){
            Console.WriteLine(e);
        }
        finally{
            con.Close();
        }

        return allstud;
    } 

    public static Student GetById(int id)
    {
        Student stud=null;

        MySqlConnection con=new MySqlConnection(constring);

        try{
            con.Open();
            string query="select * from student where id="+id;

            MySqlCommand cmd=new MySqlCommand(query,con);
            MySqlDataReader reader=cmd.ExecuteReader();

            if(reader.Read())
            {
                 stud=new Student{
                    id=int.Parse(reader["id"].ToString()),
                    name=reader["name"].ToString(),
                    place=reader["place"].ToString()
                };
            
            }


        }catch(Exception e){
            Console.WriteLine(e);
        }
        finally{
            con.Close();
        }

        return stud;
    } 
    public static void DeleteById(int id)
    {

        MySqlConnection con=new MySqlConnection(constring);

        try{
            con.Open();
            string query="delete from student where id="+id;

            MySqlCommand cmd=new MySqlCommand(query,con);
          //  MySqlDataReader reader=cmd.ExecuteReader();

            cmd.ExecuteNonQuery();

    
        }catch(Exception e){
            Console.WriteLine(e);
        }
        finally{
            con.Close();
        }

    } 

    public static void AddStudent(Student stud)
    {
        

        MySqlConnection con=new MySqlConnection(constring);

        try{
            con.Open();
            string query=$"insert into student(id,name,place) values('{stud.id}','{stud.name}','{stud.place}')";

            MySqlCommand cmd=new MySqlCommand(query,con);
                cmd.ExecuteNonQuery();


        }catch(Exception e){
            Console.WriteLine(e);
        }
        finally{
            con.Close();
        }

    } 

     public static void UpdateStudent(Student stud)
    {
        
        MySqlConnection con=new MySqlConnection(constring);

        try{
            con.Open();
            string query=$"update student set name='{stud.name}',place='{stud.place}' where id={stud.id}";
            

            MySqlCommand cmd=new MySqlCommand(query,con);
                cmd.ExecuteNonQuery();


        }catch(Exception e){
            Console.WriteLine(e);
        }
        finally{
            con.Close();
        }

    } 




}
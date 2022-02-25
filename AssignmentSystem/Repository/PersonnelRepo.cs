using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSystem.Repository
{
    class PersonnelRepo
    {
        public Personnel Login(string userName, string password)
        {
            using (var context = new AssignmentEntities())
            {
                Personnel personal = context.Personnels.Where(c => c.P_user == userName && c.P_pass == password && c.P_using=="Active").FirstOrDefault();
                return personal;
            }
        }
        public List<Personnel> GetPersonnels()
        {
            using (var context = new AssignmentEntities())
            {
                List<Personnel> personals = context.Personnels.ToList();
                return personals;
            }
        }

        public Personnel GetPersonnel(string code)
        {
            using (var context = new AssignmentEntities())
            {
                Personnel personal = context.Personnels.Where(c => c.P_id == code).FirstOrDefault();
                return personal;
            }
        }

        public Result Create(Personnel personnel)
        {
            using (var context = new AssignmentEntities())
            {
                Result result = new Result();
                using (var trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        // var model = new Personnel();
                        int maxPid = Convert.ToInt32(context.Personnels.Max(c => c.P_id));
                        maxPid += 1;
                        string pid = maxPid.ToString().PadLeft(4, '0');

                        personnel.P_id = pid;
                        //model.Pname = personnel.Pname;
                        //model.Puser = personnel.Puser;
                        //model.Ppass = personnel.Ppass;

                        context.Personnels.Add(personnel);
                        context.SaveChanges();
                        trans.Commit();

                        result.Flag = true;
                        return result;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        result.Flag = false;
                        result.Message = ex.ToString();
                        return result;
                    }

                }
            }
        }

        public Result Update(Personnel model, string code)
        {
            using (var context = new AssignmentEntities())
            {
                Result result = new Result();
                using (var trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        Personnel personnel = context.Personnels.Find(code);

                        personnel.P_name = model.P_name;
                        personnel.P_user = model.P_user;
                        personnel.P_pass = model.P_pass;
                        personnel.P_status = model.P_status;
                        personnel.P_using = model.P_using;

                        context.Entry(personnel).State = System.Data.Entity.EntityState.Modified;

                        context.SaveChanges();
                        trans.Commit();
                        result.Flag = true;
                        return result;
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        result.Flag = false;
                        return result;
                    }
                }
            }
        }

        public Result Delete(string code)
        {
            using (var context = new AssignmentEntities())
            {
                Result result = new Result();
                using (var trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        Personnel personnel = context.Personnels.Find(code);

                        context.Personnels.Remove(personnel);

                        context.SaveChanges();
                        trans.Commit();
                        result.Flag = true;
                        return result;
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        result.Flag = false;
                        return result;
                    }
                }
            }
        }

    }
}

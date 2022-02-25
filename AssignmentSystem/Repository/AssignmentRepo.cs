using AssignmentSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSystem.Repository
{
    class AssignmentRepo
    {
        AssignmentEntities context = new AssignmentEntities();

        public List<AssignmentPartial> GetAssignments()
        {
            List<AssignmentPartial> assignments = context.Assignments.Select(c => new AssignmentPartial
            {
                A_id = c.A_id,
                A_date = c.A_date,
                A_time = c.A_time,
                A_name = c.A_name,
                A_name_detail = c.A_name_detail,
                A_code = c.A_code,
                A_link = c.A_link,
                A_sander = c.A_sander,
                A_assign = c.A_assign,
                A_target = c.A_target,
                A_status = c.A_status,
                A_detail = c.A_detail,
                U_status = c.U_status,
                U_remark = c.U_remark,
                U_date1 = c.U_date1,
                U_detail1 = c.U_detail1,
                U_link1 = c.U_link1,
                U_date2 = c.U_date2,
                U_detail2 = c.U_detail2,
                U_link2 = c.U_link2,
                U_date3 = c.U_date3,
                U_detail3 = c.U_detail3,
                U_link3 = c.U_link3,
                C1 = c.C1,
                C2 = c.C2,
                C3 = c.C3,
                C4 = c.C4,
                R1 = c.R1,
                R2 = c.R2,
                R3 = c.R3,
                R4 = c.R4,
                HasDoc = c.C1 == "False" ? "" : "X",
                HasSub1 = c.C2 == "False" ? "" : "X",
                HasSub2 = c.C3 == "False" ? "" : "X",
                HasSub3 = c.C4 == "False" ? "" : "X",
                A_Brand = c.A_Brand,
                Rec1 = c.Rec1,
                Rec2 = c.Rec2,
                Rec3 = c.Rec3//,
              //  A_DateCov = DateTime.ParseExact(c.A_date, @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)

        }).OrderByDescending(c => c.A_id).ToList();
            return assignments;
        }
        public Assignment GetAssignmentByID(string code)
        {
            Assignment assignment = context.Assignments.Where(c => c.A_id == code).First();
            return assignment;

        }
        public List<AssignmentPartial> GetAssignmentsForActive()
        {
            List<AssignmentPartial> assignments = context.Assignments.Where(c => c.A_status == "Open").Select(c => new AssignmentPartial
            {
                A_id = c.A_id,
                A_date = c.A_date,
                A_time = c.A_time,
                A_name = c.A_name,
                A_name_detail = c.A_name_detail,
                A_code = c.A_code,
                A_link = c.A_link,
                A_sander = c.A_sander,
                A_assign = c.A_assign,
                A_target = c.A_target,
                A_status = c.A_status,
                A_detail = c.A_detail,
                U_status = c.U_status,
                U_remark = c.U_remark,
                U_date1 = c.U_date1,
                U_detail1 = c.U_detail1,
                U_link1 = c.U_link1,
                U_date2 = c.U_date2,
                U_detail2 = c.U_detail2,
                U_link2 = c.U_link2,
                U_date3 = c.U_date3,
                U_detail3 = c.U_detail3,
                U_link3 = c.U_link3,
                C1 = c.C1,
                C2 = c.C2,
                C3 = c.C3,
                C4 = c.C4,
                R1 = c.R1,
                R2 = c.R2,
                R3 = c.R3,
                R4 = c.R4,
                HasDoc = c.C1 == "False" ? "" : "X",
                HasSub1 = c.C2 == "False" ? "" : "X",
                HasSub2 = c.C3 == "False" ? "" : "X",
                HasSub3 = c.C4 == "False" ? "" : "X",
                A_Brand = c.A_Brand,
                Rec1 = c.Rec1,
                Rec2=c.Rec2,
                Rec3=c.Rec3//,
                //A_DateCov =  DateTime.ParseExact(c.A_date, @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)

        }).OrderByDescending(c=>c.A_id).ToList();

            return assignments;
        }

        public Result Create(Assignment assignment)
        {
            Result result = new Result();
            using (var trans =context.Database.BeginTransaction())
            {
                try
                {
                    //mf => mf.AuditItems.OrderByDescending(ai => ai.DateOfAction).First().Step == 1);
                    // int maxId = Convert.ToInt32( context.Assignments.OrderByDescending(c => c.A_id).First().A_id);

                    int maxId = Convert.ToInt32(context.Assignments.AsEnumerable().OrderByDescending(c => int.Parse( c.A_id)).First().A_id);
                   
                     maxId += 1;

                    assignment.A_id = maxId.ToString();

                    context.Assignments.Add(assignment);
                    context.SaveChanges();
                    trans.Commit();

                    result.Code = maxId.ToString();
                    result.Flag = true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    result.Flag = false;
                    result.Message = ex.ToString();

                    return result;
                }

                return result;

            }
        }

        //update pathFolder
        public Result UpdatePathFolder(Assignment model, string code)
        {
            Result result = new Result();
            using (var trans = context.Database.BeginTransaction())
            {
                try
                {

                    Assignment assignment = context.Assignments.Find(code);

                    assignment.A_link = model.A_link;
                    assignment.U_link1 = model.U_link1;
                    assignment.U_link2 = model.U_link2;
                    assignment.U_link3 = model.U_link3;

                    context.Entry(assignment).State = System.Data.Entity.EntityState.Modified;

                    context.SaveChanges();
                    trans.Commit();
                    result.Code = code;
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

        public Result Update(Assignment model, string code)
        {
            Result result = new Result();
            using (var trans = context.Database.BeginTransaction())
            {
                try
                {

                    Assignment assignment = context.Assignments.Find(code);
                    assignment.A_date = model.A_date;
                    assignment.A_time = model.A_time;
                    assignment.A_name = model.A_name;
                    assignment.A_name_detail = model.A_name_detail;
                    assignment.A_code = model.A_code;
                    assignment.A_link = model.A_link;
                    assignment.A_sander = model.A_sander;
                    assignment.A_assign = model.A_assign;
                    assignment.A_target = model.A_target;
                    assignment.A_status = model.A_status;
                    assignment.A_detail = model.A_detail;
                    assignment.U_status = model.U_status;
                    assignment.U_remark = model.U_remark;
                    assignment.U_date1 = model.U_date1;
                    assignment.U_detail1 = model.U_detail1;
                    assignment.U_link1 = model.U_link1;
                    assignment.Rec1 = model.Rec1;
                    assignment.U_date2 = model.U_date2;
                    assignment.U_detail2 = model.U_detail2;
                    assignment.U_link2 = model.U_link2;
                    assignment.Rec2 = model.Rec2;
                    assignment.U_date3 = model.U_date3;
                    assignment.U_detail3 = model.U_detail3;
                    assignment.U_link3 = model.U_link3;
                    assignment.Rec3 = model.Rec3;
                    assignment.C1 = model.C1;
                    assignment.C2 = model.C2;
                    assignment.C3 = model.C3;
                    assignment.C4 = model.C4;
                    assignment.A_Brand = model.A_Brand;


                    context.Entry(assignment).State = System.Data.Entity.EntityState.Modified;

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

        public Result Delete(string code)
        {
            Result result = new Result();
            using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    
                    Assignment assignment = context.Assignments.Find(code);
                    assignment.A_status = "Delete";
                    
                    context.Entry(assignment).State = System.Data.Entity.EntityState.Modified;

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

        public Result UpdateTarget(List<string> AIDs , DateTime TargetDate)
        {
            Result result = new Result();
            using (var trans = context.Database.BeginTransaction())
            {
                try
                {

                   List<Assignment> assignments = context.Assignments.Where(c => AIDs.Contains(c.A_id)).ToList();

                    foreach (var item in assignments)
                    {
                        item.A_target = TargetDate.ToString("dd/MM/yyyy");

                        context.Entry(item).State = System.Data.Entity.EntityState.Modified;

                        context.SaveChanges();
                    }

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

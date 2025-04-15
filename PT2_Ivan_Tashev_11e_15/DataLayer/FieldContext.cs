using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusinessLayer;
namespace DataLayer
{
    public class FieldContext:IDb<Field,int>
    {
        private AppDbContext dbContext;
        public FieldContext(AppDbContext appContext)
        {
            dbContext = appContext;
        }
        public void Create(Field item)
        {
            dbContext.Fields.Add(item);
            dbContext.SaveChanges();
        }
        public Field Read(int id, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Field> query = dbContext.Fields;
            if (useNavigationalProperties)
            {
                query = query.Include(f => f.Users);
            }
            if (isReadOnly)
            {
                query = query.AsNoTrackingWithIdentityResolution();
            }
            Field field = query.FirstOrDefault(f => f.Id == id);
            if (field == null)
            {
                throw new Exception("Field not found");
            }
            return field;
        }
        public List<Field> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Field> query = dbContext.Fields;
            if (useNavigationalProperties)
            {
                query = query.Include(f => f.Users);
            }
            if (isReadOnly)
            {
                query = query.AsNoTrackingWithIdentityResolution();
            }
            return query.ToList();
        }
        public void Update(Field field, bool useNavigationalProperties = false)
        {
            Field fieldFromContext = dbContext.Fields.Find(field.Id);
            fieldFromContext.Name = field.Name;
            if (useNavigationalProperties)
            {
                List<User> users = new List<User>();
                for (int i = 0; i < field.Users.Count; i++)
                {
                    User user = dbContext.Users.Find(field.Users[i]);
                    if (user != null)
                    {
                        users.Add(user);
                    }
                    else
                    {
                        users.Add(field.Users[i]);
                    }
                }
                fieldFromContext.Users = users;
            }
            dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Field field = dbContext.Fields.Find(id);
            if (field != null)
            {
                dbContext.Fields.Remove(field);
                dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Field not found");
            }
        }
    }
}
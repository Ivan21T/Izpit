using DataLayer;
using BusinessLayer;
namespace TestingLayer
{
    [TestFixture]
    public class FieldContextTests
    {
        static FieldContext fieldContext;
        static FieldContextTests()
        {
            fieldContext = new FieldContext(TestManager.dbContext);
        }
        [Test]
        public void CreateField()
        {
            Field field = new Field("math");
            int fieldsBefore = TestManager.dbContext.Fields.Count();
            fieldContext.Create(field);
            int fieldsAfter = TestManager.dbContext.Fields.Count();
            Field lastField = TestManager.dbContext.Fields.Last();
            Assert.That(fieldsBefore + 1 == fieldsAfter && lastField.Name == field.Name, "Names are not equal or field is not created!");
        }
        [Test]
        public void DeleteField()
        {
            Field newField = new Field("english");
            fieldContext.Create(newField);

            List<Field> fields = fieldContext.ReadAll();
            int fieldBefore = fields.Count;
            Field genre = fields.Last();

            fieldContext.Delete(genre.Id);

            int genresAfter = fieldContext.ReadAll().Count;
            Assert.That(fieldBefore == genresAfter + 1, "Delete() does not delete a field!");
        }
        [Test]
        public void ReadField()
        {
            Field newField = new Field("sport");
            fieldContext.Create(newField);

            Field genre = fieldContext.Read(newField.Id);

            Assert.That(genre.Name == "sport", "Read() does not get field by id!");
        }

        [Test]
        public void ReadAllFields()
        {
            int fieldsBefore = TestManager.dbContext.Fields.Count();

            int fieldsAfter = fieldContext.ReadAll().Count;

            Assert.That(fieldsBefore == fieldsAfter, "ReadAll() does not return all of the Fields!");
        }
        [Test]
        public void UpdateField()
        {
            Field newField = new Field("physics");
            fieldContext.Create(newField);

            Field lastField = fieldContext.ReadAll().Last();
            lastField.Name = "Updated Field";

            fieldContext.Update(lastField, false);

            Assert.That(fieldContext.Read(lastField.Id).Name == "Updated Field",
            "Update() does not change the Field's name!");
        }
    }
}
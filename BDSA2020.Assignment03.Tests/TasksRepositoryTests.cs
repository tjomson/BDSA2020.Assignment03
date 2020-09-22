using Xunit;
using BDSA2020.Assignment03.Entities;
using BDSA2020.Assignment03;
using System.Collections.Generic;

namespace BDSA2020.Assignment03.Tests
{
    public class TasksRepositoryTests
    {
        [Fact]
        public void TestCreate()
        {
            var context = new KanbanContext();
            var taskRepository = new TasksRepository(context);
            var actual = taskRepository.Create(new TaskDTO {Id = 1, AssignedToId = 1});
            Assert.Equal(1, actual);
        }

        [Fact]
        public void TestFindById()
        {
            var context = new KanbanContext();
            var taskRepository = new TasksRepository(context);


            var expected = new TaskDetailsDTO {
                Id = 1,
                Title = "Do something",
                State = State.ACTIVE,
                Description = "very cool task",
                AssignedToId = 1,
                AssignedToEmail = "john@email.dk",
                AssignedToName = "john",

            };

            var expectedtags = new List<string>(){"tag1", "tag2"};
            var actual = taskRepository.FindById(1);

            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Title, actual.Title);
            Assert.Equal(expected.State, actual.State);
            Assert.Equal(expected.Description, actual.Description);
            Assert.Equal(expected.AssignedToId, actual.AssignedToId);
            Assert.Equal(expected.AssignedToEmail, actual.AssignedToEmail);
            Assert.Equal(expected.AssignedToName, actual.AssignedToName);

            var counter = 0;
            foreach (var tag in actual.Tags)
            {
                Assert.Equal(expectedtags[counter], tag);
                counter++;
            }


        }
    }
}

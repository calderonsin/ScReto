//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Xunit;

//namespace Domain.Entities.Usuarios.test
//{
//    public class UserTest
//    {   
//        [Fact]
//        public void shouldBuildNewUser()
//        {
//            User user_expected = new User(Guid.NewGuid(), "1022098470", "Jorge",25,"Sofka", "Medellín");
//            User user_actual = User.Build("1022098470", "Jorge",25,"Sofka", "Medellín");

//            Assert.Equal(user_expected.identity, user_actual.identity);
//            Assert.Equal(user_expected.name, user_actual.name);
//            Assert.Equal(user_expected.age, user_actual.age);
//            Assert.Equal(user_expected.company, user_actual.company);
//            Assert.Equal(user_expected.city, user_actual.city);


//        }

//        [Fact]
//        public void shouldConstructNewUser()
//        {
//            User user_expected = User.Build("1022098470", "Jorge", 25, "Sofka", "Medellín");
//            User user_actual = new User(Guid.NewGuid(), "1022098470", "Jorge", 25, "Sofka", "Medellín");


//            Assert.Equal(user_expected.identity, user_actual.identity);
//            Assert.Equal(user_expected.name, user_actual.name);
//            Assert.Equal(user_expected.age, user_actual.age);
//            Assert.Equal(user_expected.company, user_actual.company);
//            Assert.Equal(user_expected.city, user_actual.city);


//        }
//    }
//}

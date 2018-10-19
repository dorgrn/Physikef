using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Physikef.ScreenManagement.OptionsScreens
{
    public class StudentInputTextSupplier : AbstractInputTextSupplier
    {
        public override async Task<IEnumerable<string>> GetInputTextsAsync()
        {
            IEnumerable<User> students = await ServicesManager.GetDataAccessLayer().GetAllUsersAsync();
            return students.Where(user => user.usertype == "Student").Select(user => user.email);
        }
    }
}
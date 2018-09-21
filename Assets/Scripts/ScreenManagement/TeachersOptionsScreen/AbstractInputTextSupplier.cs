using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Physikef.ScreenManagement.TeachersOptionsScreen
{
    public abstract class AbstractInputTextSupplier : MonoBehaviour
    {
        public abstract Task<IEnumerable<string>> GetInputTextsAsync();
    }
}
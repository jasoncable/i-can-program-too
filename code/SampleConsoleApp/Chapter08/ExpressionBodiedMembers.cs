using System;
namespace SampleConsoleApp.Chapter08
{
    public class ExpressionBodiedMembers
    {
        private string _name;
        public ExpressionBodiedMembers(string s) => _name = s;
        public string ReturnUpperCase() => _name.ToUpper();
        public void SetToUpperCase() => _name = _name.ToUpper();
        public string Name
        {
            get => _name;
            set => _name = value;
        }
    }
}



namespace MusicApp2
{
    public class SearchValue
    {
        private string textValue;

        public string TextValue { get => textValue; set => textValue = value; }
        public int Id { get => id; set => id = value; }

        private int id;

        public SearchValue(string pTextValue)
        {
            textValue = pTextValue;
        }

        public SearchValue()
        { }
        public SearchValue(int pId)
        { id = pId; }
    }
}

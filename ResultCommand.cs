namespace CNC_Assist
{
    /// <summary>
    /// Класс описания результата выполнения действия
    /// </summary>
    class ResultCommand
    {
        public bool Status = true;
        public string ErrorMessage = "";

        public ResultCommand(bool _status, string _message)
        {
            Status = _status;
            ErrorMessage = _message;
        }
    }
}

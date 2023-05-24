namespace HomeApi.Data.Queries
{
    /// <summary>
    /// Класс для передачи дополнительных параметров при обновлении устройства
    /// </summary>
    public class UpdateRoomQuery
    {
     
        public string NewName { get; set; }
        public int NewArea { get; set; }
        public bool NewGasConnected { get; set; }
        public int NewVoltage { get; set; }

        public UpdateRoomQuery(string newName = null, int newArea = 0, bool newGasConnected = false, int newVoltage = 0)
        {
            NewName = newName;
            NewArea = newArea;
            NewGasConnected = newGasConnected;
            NewVoltage = newVoltage;
        }
    }
}
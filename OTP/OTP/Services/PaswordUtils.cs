namespace OTP.Services
{
    public class PaswordUtils
    {
        public DateTime date { get; set; }
        public string Password { get; set; }

        public string GeneratePassword()
        {
            Random random = new Random();
            int[] numbers = new int[6];
            for (int i = 0; i < 6; i++)
            {
                numbers[i] = random.Next(1, 10);
            }
            date = DateTime.Now;
            Password = string.Join("", numbers);
            return Password;
        }

    }
}

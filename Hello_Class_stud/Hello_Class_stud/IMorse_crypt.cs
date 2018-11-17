namespace Hello_Class_stud
{
    //Define interface IMorse_crypt wicth two methods  
    //crypt - to crypt the string
    //decrypt - to decrypt array of strings
    public interface IMorse_crypt
    {
        string Crypt(string stringToCrypt);
        string Decrypt(string[] stringsToDecrypt);
    }
}

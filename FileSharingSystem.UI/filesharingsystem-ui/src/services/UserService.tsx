import axios from 'axios';
 
export default async function AddUser(email:FormDataEntryValue | null, password: FormDataEntryValue | null, firstName:FormDataEntryValue | null, lastName:FormDataEntryValue | null,
    dateOfBirth:FormDataEntryValue | null) {
      if(dateOfBirth != null)
      {
        var dayMonthYear = dateOfBirth.toString().split("-");
        dateOfBirth = dayMonthYear[2] + "-" + dayMonthYear[1] + "-" + dayMonthYear[0];
      }
  try {
    await axios.post('https://localhost:7177/api/User', JSON.stringify(
    {
        email, password, firstName, lastName, dateOfBirth, gender:0
    }
  ),
  {
    headers: {'Content-Type': 'application/json'}
  });
  } catch (error) {
    console.log(error);
  }
}
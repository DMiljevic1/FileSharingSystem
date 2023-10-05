import axios from 'axios';
 
export default async function Login(username:FormDataEntryValue | null, password: FormDataEntryValue | null) {
    
  try {
    const response = await axios.post('https://localhost:7177/api/Auth', JSON.stringify(
    {
      username, password
    }
  ),
  {
    headers: {'Content-Type': 'application/json'}
  });
  localStorage.setItem('token', response.data.token);
  } catch (error) {
    console.log(error);
  }
}
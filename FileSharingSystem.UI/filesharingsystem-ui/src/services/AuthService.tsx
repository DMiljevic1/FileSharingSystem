import axios from 'axios';
 
export default async function Login(email:FormDataEntryValue | null, password: FormDataEntryValue | null) : Promise<Boolean>{
    let loginResult = false;
  try {
    const response = await axios.post('https://localhost:7177/api/Auth', JSON.stringify(
    {
      email, password
    }
  ),
  {
    headers: {'Content-Type': 'application/json'}
  });
  if(await response.data.success)
  {
    localStorage.setItem('token', response.data.token);
    loginResult = true;
  }
  } catch (error) {
    console.log(error);
  }
  return await loginResult.valueOf();
}
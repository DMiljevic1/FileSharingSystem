import React, {useRef, useEffect, useState} from "react";
import "../../styles/styles.css"
import axios from "axios";

export const Login = (props) => {
    const userRef = useRef();
    const errorRef = useRef();

    const [username, setusername] = useState('');
    const [pass, setPass] = useState('');
    const [errorMsg, setErrMsg] = useState('');

    useEffect(() => {
        userRef.current.focus();
    }, [])

    useEffect(() => {
        setErrMsg('');
    }, [username, pass])

    const handleSubmit = (e) => {
        e.preventDefault();
        console.log(username);
        const response = axios.post('https://localhost:7177/api/Auth',
    {
        username: username,
        password: pass
    })
      .then((response) => {
        console.log(response.data)
      })
      .catch((err) => {
        console.log(response.data)
      })
    }
    return (
        <div className="auth-form-container">
        <h2>Login</h2>
        <form className="login-form" onSubmit={handleSubmit}>
            <label htmlFor="username">username</label>
            <input value={username} onChange={(e) => setusername(e.target.value)}type="username" placeholder="username" id="username" name="username" ref={userRef}/>
            <label htmlFor="password">password</label>
            <input value={pass} onChange={(e) => setPass(e.target.value)} type="password" placeholder="password" id="password" name="password" />
            <button className="login-button" type="submit">Log In</button>
        </form>
       
    </div>
    )
}
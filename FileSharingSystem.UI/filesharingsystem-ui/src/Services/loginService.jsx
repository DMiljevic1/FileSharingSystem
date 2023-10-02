import { useState, useEffect } from "react";

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
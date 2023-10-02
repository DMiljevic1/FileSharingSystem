import Axios from "axios"
import * as Constants from "../constants/constants.jsx"
import { useState, useEffect } from "react";


export default class homepageService {

    getUserInfo({ id }) {
        const [firstName, setFirstName ] = useState("");
    const [lastName, setLastName ] = useState("");
    
    var callApi = Constants.BASE_API_URL + Constants.CONTROLLER_NAME[0] + "?userId=" + `${id}` 

    const fetchNames = () => {
        Axios.get(callApi).then((res) => {
            setFirstName(res.data.firstName);
            setLastName(res.data.lastName);
        })
    }

    useEffect(() => {
        fetchNames();
    }, []);

    return [firstName, lastName]
    }
}

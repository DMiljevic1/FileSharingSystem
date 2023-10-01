import Navbar from "../Components/Navbar";
import ProfileImage from "../Components/ProfileImage";
import Customtextbox from "../Components/Customtextbox";
import CustomTable from "../Components/CustomTable";
import { useEffect, useState } from "react";
import Axios from "axios";

function Home() {

    const [firstName, setFirstName ] = useState("");
    const [lastName, setLastName ] = useState("");

    const fetchNames = () => {
        Axios.get("https://localhost:7177/api/User?userId=1").then((res) => {
            setFirstName(res.data.firstName);
            setLastName(res.data.lastName);
        })
    }

    useEffect(() => {
        fetchNames();
    }, []);
    


    return (
        <div>
            <Navbar/>
            <div className="home-container">
                <div>
                    <ProfileImage/>
                    <Customtextbox customMessage="Ime: " className="text-box1" name={firstName}/>
                    <Customtextbox customMessage="Prezime: " className="text-box2" name={lastName}/>
                </div>
                <CustomTable/>
            </div>
        </div>
    )
}

export default Home
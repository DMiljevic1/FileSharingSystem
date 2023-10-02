import Navbar from "../Components/Navbar";
import ProfileImage from "../Components/ProfileImage";
import Customtextbox from "../Components/Customtextbox";
import CustomTable from "../Components/CustomTable";
import { AppContext } from "../context/Appcontext"
import { useContext } from "react";

function Home() {

    const {
        services: {
            homepageService
        }
    } = useContext(AppContext)

    var res = homepageService.getUserInfo({id:1});

    return (
        <div>
            <Navbar/>
            <div className="home-container">
                <div>
                    <ProfileImage/>
                    <Customtextbox customMessage="Ime: " className="text-box1" name={res[0]}/>
                    <Customtextbox customMessage="Prezime: " className="text-box2" name={res[1]}/>
                </div>
                <CustomTable/>
            </div>
        </div>
    )
}

export default Home
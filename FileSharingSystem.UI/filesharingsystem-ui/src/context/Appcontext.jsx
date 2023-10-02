import { createContext } from "react";
import homepageService  from "../Services/homepageService.jsx"
const services = {
    homepageService : new homepageService()
}

const AppContext = createContext();
const { Provider } = AppContext;

const AppProvider = ({children}) => {
    return<Provider value={{ services }}>{children}</Provider>
}

export { AppContext, AppProvider }
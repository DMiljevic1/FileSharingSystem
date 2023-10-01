import "../../styles/styles.css"
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome"

function CustomTable () {
    return (
        <div className="table-container">
            <table>
                <thead>
                    NASLOV TABLICE
                </thead>
                <tr>
                     <td>
                        <div>
                            Request
                        </div>
                        <div>
                            <button className="accept-button"><FontAwesomeIcon icon="fa-solid fa-check" /></button>
                            <button className="decline-button"><FontAwesomeIcon icon="fa-solid fa-xmark" /></button>
                        </div> 
                     </td> 
                </tr>
                <tr>
                     <td>
                        <div>
                            Request
                        </div>
                        <div>
                            <button className="accept-button"><FontAwesomeIcon icon="fa-solid fa-check" /></button>
                            <button className="decline-button"><FontAwesomeIcon icon="fa-solid fa-xmark" /></button>
                        </div> 
                     </td> 
                </tr>
                <tr>
                     <td>
                        <div>
                            Request
                        </div>
                        <div>
                            <button className="accept-button"><FontAwesomeIcon icon="fa-solid fa-check" /></button>
                            <button className="decline-button"><FontAwesomeIcon icon="fa-solid fa-xmark" /></button>
                        </div> 
                     </td> 
                </tr>
                <tr>
                     <td>
                        <div>
                            Request
                        </div>
                        <div>
                            <button className="accept-button"><FontAwesomeIcon icon="fa-solid fa-check" /></button>
                            <button className="decline-button"><FontAwesomeIcon icon="fa-solid fa-xmark" /></button>
                        </div> 
                     </td> 
                </tr>
                <tr>
                     <td>
                        <div>
                            Request
                        </div>
                        <div>
                            <button className="accept-button"><FontAwesomeIcon icon="fa-solid fa-check" /></button>
                            <button className="decline-button"><FontAwesomeIcon icon="fa-solid fa-xmark" /></button>
                        </div> 
                     </td> 
                </tr>
                <tr>
                     <td>
                        <div>
                            Request
                        </div>
                        <div>
                            <button className="accept-button"><FontAwesomeIcon icon="fa-solid fa-check" /></button>
                            <button className="decline-button"><FontAwesomeIcon icon="fa-solid fa-xmark" /></button>
                        </div> 
                     </td> 
                </tr>
                <tfoot>
                    <button>1</button>
                    <button>2</button>
                    <button>3</button>
                </tfoot>
            </table>
        </div>
    )
}

export default CustomTable 
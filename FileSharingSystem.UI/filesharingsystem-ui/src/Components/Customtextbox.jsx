import "../../styles/styles.css"

function Customtextbox (props) {
    
    
    return (
        <div className="text-box1">
            {props.customMessage}{props.name}
        </div>
    )

}

export default Customtextbox
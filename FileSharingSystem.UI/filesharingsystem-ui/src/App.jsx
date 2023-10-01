import './App.css'
import Home from'./Pages/Home'
import { Login } from './Pages/Login' 
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'
import ReactDOM from 'react-dom'
import { library } from '@fortawesome/fontawesome-svg-core'
import { fas } from '@fortawesome/free-solid-svg-icons'

library.add(fas)

function App() {

  const homeStyle = {
    backgroundColor : "white"
  }

  return (
    <>
      <div className="App">
        <Router>
          <Routes>
            <Route exact path="/" element={<Login/>}></Route>
            <Route exact path="/Home" element={<Home style={homeStyle}/>}></Route>
          </Routes>
        </Router>
      </div>
    </>
  )
}

export default App

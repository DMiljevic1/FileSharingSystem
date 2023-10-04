import './App.css'
import SignIn from './pages/SignIn'
import SignUp from './pages/SignUp'
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'

function App() {
  return (
    <>
    <Router>
		  <Routes>
			  <Route path="/" element={<SignIn/>} />
			  <Route path="/SignUp" element={<SignUp/>} />
        <Route path="/Home" element={<SignIn/>} />
		  </Routes>
    </Router>
    </>
  )
}

export default App

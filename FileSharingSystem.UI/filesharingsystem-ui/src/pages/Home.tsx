import Navbar from "../components/Navbar"
import BasicTable from "../components/BasicTable"
import ImageCard from "../components/ImageCard"
import Box from '@mui/material/Box';
import "../styles/home.css"
import LoadUserInfo from "../services/GroupUserService";

export default function Home(){
  
  const data = LoadUserInfo(1);
  
  return (
    <Box sx={{ display: "flex",margin: 0, flexWrap: "no-wrap"}}>
      <Navbar></Navbar>
        <ImageCard></ImageCard>
      <Box sx={ { width: "100%"} }>
        <BasicTable></BasicTable>
      </Box>
    </Box>
  )
}
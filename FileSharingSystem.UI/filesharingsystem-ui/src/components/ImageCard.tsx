import * as React from 'react';
import Box from '@mui/material/Box';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import FlyingButton from './FlyingButton'; 
import { Avatar, Typography } from '@mui/material';
import GetUserGroupRelation from "../services/GroupUserService";
import { User } from "../services/GroupUserService"
 
const data = await GetUserGroupRelation(1) as User;



const card = (
  <React.Fragment>
    <CardContent sx={{ display: "flex", justifyContent:"center"}}>
      <Avatar alt="Profile Image" src="" sx={{ height:"150px", width:"150px"}}/>
    </CardContent>
    <CardActions  sx={{display: "flex", flexDirection:"column"}}>
      <input type="file" hidden style={{ display: "none"}} id="upload-btn"/>
      <label htmlFor='upload-btn'>
        <FlyingButton></FlyingButton>
      </label>
      
      <Box sx={{display: "flex", flexDirection: "row"}}>
        <Typography variant='h6' gutterBottom padding="5px">{data.firstName}</Typography>
        <Typography variant='h6' gutterBottom padding="5px">{data.lastName}</Typography>
      </Box>
      <Typography variant='h6' gutterBottom>{data.email}</Typography>
    </CardActions>
  </React.Fragment>
);

export default function ImageCard() {
  return (
    <Box sx={{ minWidth: 275, minHeight: 500, mr:"100px"}}>
      <Card sx={{ height: 450,width: 350}} variant="outlined">{card}</Card>
    </Box>
  );
}

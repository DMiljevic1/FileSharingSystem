import axios from 'axios'

export type User = {
    userId: number;
    firstName: string;
    lastName: string;
    email: string;
    phone_number: string;
}

export default async function GetUserGroupRelation(userId : number | null ){

    try{
        const { data, status } = await axios.get<User>(
            "https://localhost:7177/api/User?userId="  + `${userId}`,
            {
                headers: {
                    Accept: 'application/json',
                },
            },
        );

        console.log(JSON.stringify(data, null, 4));

        console.log('response status is: ', status);

        return data;
    }
    catch(error){
        if(axios.isAxiosError(error)) {
            console.log('error message: ', error.message);
            return error.message;
        }
        else {
            console.log("unexpected error: ", error);
            return "Unexpected error";
        }
    }
}
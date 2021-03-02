import { useParams } from "react-router-dom"



function Owners(){
    const {buildingId, unitId} = useParams();
    const owners = apiService.getRequest(`building/${buildingId}/units/${unitId}/owners`);

    return(
        
    )
}
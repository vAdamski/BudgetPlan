import {useParams} from "react-router-dom";

function Plans(){
    const {budgetPlanId} = useParams();

    return (
        <div>
            <h1>Plany</h1>
            <p>Id planu budżetowego: {budgetPlanId}</p>
        </div>
    );
}

export default Plans;
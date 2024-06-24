import './dashboard.css'
import {useParams} from "react-router-dom";
import CreateTransactionDetails from "../../common/createTransactionDetails/CreateTransactionDetails.jsx";

function Dashboard() {
    const {budgetPlanId} = useParams();

    return (
        <div className={'grid-container'}>
            <div className={'grid-item'}>
                <CreateTransactionDetails budgetPlanId={budgetPlanId}/>
            </div>
        </div>
    );
}

export default Dashboard;
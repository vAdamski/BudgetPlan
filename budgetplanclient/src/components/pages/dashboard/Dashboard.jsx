import './dashboard.css'
import {useParams} from "react-router-dom";
import CreateTransactionDetails from "../../common/createTransactionDetails/CreateTransactionDetails.jsx";
import SummaryChartsCard from "../../common/SummaryChartsCard.jsx";

function Dashboard() {
    const {budgetPlanId} = useParams();

    return (
        <div className={'dashboard-grid-container'}>
            <div className={'create-details-transaction-form'}>
                <CreateTransactionDetails budgetPlanId={budgetPlanId}/>
            </div>
            <div className={'summary-charts-card'}>
                <SummaryChartsCard budgetPlanId={budgetPlanId}/>
            </div>
        </div>
    );
}

export default Dashboard;
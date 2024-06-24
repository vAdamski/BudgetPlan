import {useParams} from "react-router-dom";

function BudgetPlanSettings() {
    const {budgetPlanId} = useParams();

    return (
        <div>
            <h1>Ustawienia planu budżetowego</h1>
            <p>Id planu budżetowego: {budgetPlanId}</p>
        </div>
    );
}

export default BudgetPlanSettings;
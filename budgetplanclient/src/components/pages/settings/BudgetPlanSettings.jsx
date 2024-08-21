import {useParams} from "react-router-dom";
import AccessedUsersCard from "./AccessedUsersCard.jsx";

function BudgetPlanSettings() {
    const {budgetPlanId} = useParams();

    return (
        <div className={'container-fluid'}>
            <h2 className={'text-center'}>
                Ustawienia planu budżetowego
            </h2>
            <div className={'row'}>
                <div className={'col-4'}>
                    <AccessedUsersCard budgetPlanId={budgetPlanId}/>
                </div>
            </div>
        </div>
    );
}

export default BudgetPlanSettings;
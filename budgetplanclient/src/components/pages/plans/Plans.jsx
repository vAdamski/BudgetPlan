import './plans.css';
import {useParams} from "react-router-dom";
import useBudgetPlansApi from "../../../services/api/budgetPlans.jsx";
import PlansSelectList from "./PlansSelectList.jsx";
import {useEffect, useState} from "react";
import BudgetPlanBaseTableView from "./BudgetPlanBaseTableView.jsx";

function Plans() {
    const {budgetPlanId} = useParams();
    const {getBudgetPlanBasesForBudgetPlan} = useBudgetPlansApi();
    const [budgetPlanBases, setBudgetPlanBases] = useState([]);
    const [selectedBudgetPlanBaseId, setSelectedBudgetPlanBaseId] = useState('');

    const handlePlanChange = (selectedId) => {
        setSelectedBudgetPlanBaseId(selectedId);
    };

    useEffect(() => {
        const fetchBudgetPlanBases = async () => {
            const data = await getBudgetPlanBasesForBudgetPlan(budgetPlanId);
            setBudgetPlanBases(data.budgetPlanBasesDtos || []);

            if (data.budgetPlanBasesDtos.length > 0) {
                setSelectedBudgetPlanBaseId(data.budgetPlanBasesDtos[0].id)
            }
        }

        fetchBudgetPlanBases();
    }, []);

    return (
        <div>
            <div className={'top-bar'}>
                <PlansSelectList budgetPlanBases={budgetPlanBases} handleChange={handlePlanChange}/>
            </div>

            <div className={'table-card'}>
                <BudgetPlanBaseTableView budgetPlanBaseId={selectedBudgetPlanBaseId}/>
            </div>
        </div>
    );
}

export default Plans;
import {useParams} from "react-router-dom";
import useBudgetPlansApi from "../../../services/api/budgetPlans.jsx";
import {useEffect, useState} from "react";
import BudgetPlanBaseTableView from "./BudgetPlanBaseTableView.jsx";
import {Container, Tab, Tabs} from "react-bootstrap";

function Plans() {
    const {budgetPlanId} = useParams();
    const {getBudgetPlanBasesForBudgetPlan} = useBudgetPlansApi();
    const [budgetPlanBases, setBudgetPlanBases] = useState([]);

    useEffect(() => {
        const fetchBudgetPlanBases = async () => {
            const data = await getBudgetPlanBasesForBudgetPlan(budgetPlanId);
            setBudgetPlanBases(data.budgetPlanBasesDtos || []);
        }

        fetchBudgetPlanBases();
    }, []);

    return (
        <Container fluid>
            <Tabs id="uncontrolled-tab-example">
                {budgetPlanBases.map((budgetPlanBase) => (
                    <Tab className={'border p-2'} key={budgetPlanBase.id} eventKey={budgetPlanBase.id} title={`${budgetPlanBase.dateFrom} - ${budgetPlanBase.dateTo}`}>
                        <BudgetPlanBaseTableView budgetPlanBaseId={budgetPlanBase.id} dateFrom={budgetPlanBase.dateFrom} dateTo={budgetPlanBase.dateTo}/>
                    </Tab>
                ))}
            </Tabs>
        </Container>
    );
}

export default Plans;
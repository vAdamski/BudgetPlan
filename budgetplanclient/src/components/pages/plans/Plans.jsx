import {useParams} from "react-router-dom";
import useBudgetPlansApi from "../../../services/api/budgetPlans.jsx";
import {useEffect, useState} from "react";
import BudgetPlanBaseTableView from "./BudgetPlanBaseTableView.jsx";
import {Container, Tab, Tabs} from "react-bootstrap";
import CreatePlanForm from "./CreatePlanForm.jsx"; // Import the modal component

function Plans() {
    const {budgetPlanId} = useParams();
    const {getBudgetPlanBasesForBudgetPlan} = useBudgetPlansApi();
    const [budgetPlanBases, setBudgetPlanBases] = useState([]);
    const [update, setUpdate] = useState(false);

    const handleUpdate = () => {
        setUpdate(!update);
    }

    useEffect(() => {
        const fetchBudgetPlanBases = async () => {
            const data = await getBudgetPlanBasesForBudgetPlan(budgetPlanId);
            setBudgetPlanBases(data.budgetPlanBasesDtos || []);
        }

        fetchBudgetPlanBases();
    }, [budgetPlanId, update]);

    return (
        <>
            <Container fluid>
                <Tabs id="uncontrolled-tab-example">
                    {budgetPlanBases.map((budgetPlanBase) => (
                        <Tab className={'border p-2'} key={budgetPlanBase.id} eventKey={budgetPlanBase.id} title={`${budgetPlanBase.dateFrom} - ${budgetPlanBase.dateTo}`}>
                            <BudgetPlanBaseTableView budgetPlanBaseId={budgetPlanBase.id} dateFrom={budgetPlanBase.dateFrom} dateTo={budgetPlanBase.dateTo}/>
                        </Tab>
                    ))}
                    <Tab className={'border p-2'} title={'Utwórz'} eventKey={'x'}>
                        <CreatePlanForm budgetPlanId={budgetPlanId} handleUpdate={handleUpdate}/>
                    </Tab>
                </Tabs>
            </Container>
        </>
    );
}

export default Plans;
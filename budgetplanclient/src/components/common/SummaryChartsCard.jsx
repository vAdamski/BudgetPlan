import SummaryCharts from "./SummaryCharts.jsx";
import {Card, CardBody, CardHeader} from "react-bootstrap";
import {useEffect, useState} from "react";
import useBudgetPlansApi from "../../services/api/budgetPlans.jsx";

function SummaryChartsCard({budgetPlanId}) {
    const {getBudgetPlanBasesForBudgetPlan} = useBudgetPlansApi();
    const [selectedBudgetPlanBaseId, setSelectedBudgetPlanBaseId] = useState('');

    const [budgetPlanBases, setBudgetPlanBases] = useState([]);

    useEffect(() => {
        const fetchBudgetPlanBases = async () => {
            const data = await getBudgetPlanBasesForBudgetPlan(budgetPlanId);
            setBudgetPlanBases(data.budgetPlanBasesDtos || []);

            console.log(data);
        }

        fetchBudgetPlanBases().then();
    }, [budgetPlanId]);

    return (
        <Card>
            <CardHeader className={'text-start'} style={{backgroundColor: '#111111'}}>
                <a style={{color: 'white'}}>Podsumowanie: </a>
                <select value={selectedBudgetPlanBaseId}
                        onChange={e => setSelectedBudgetPlanBaseId(e.target.value)}>
                    <option value={''}>Cały okres</option>
                    {budgetPlanBases.map((budgetPlanBase) => (
                        <option key={budgetPlanBase.id}
                                value={budgetPlanBase.id}>
                            {budgetPlanBase.dateFrom} - {budgetPlanBase.dateTo}
                        </option>
                    ))}
                </select>
            </CardHeader>
            <CardBody>
                <SummaryCharts budgetPlanId={budgetPlanId} budgetPlanBaseId={selectedBudgetPlanBaseId}/>
            </CardBody>
        </Card>
    );
}

export default SummaryChartsCard;
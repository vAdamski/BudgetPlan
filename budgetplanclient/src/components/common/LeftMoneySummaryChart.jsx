import './SummaryCharts.css';
import {useEffect, useState} from "react";
import useDataSummaryApi from "../../services/api/dataSummaryDataApi.jsx";

function LeftMoneySummaryChart({budgetPlanId, budgetPlanBaseId}) {
    const {fetchLeftMoneySummary} = useDataSummaryApi();

    const [leftMoney, setLeftMoney] = useState(0);

    useEffect(() => {
        const fetchPieChartData = async () => {

            const value = await fetchLeftMoneySummary(budgetPlanId, budgetPlanBaseId);

            setLeftMoney(value);
        };

        fetchPieChartData().then();
    }, [budgetPlanId, budgetPlanBaseId]);

    return (
        <div className="left-money-summary-chart text-center">
            <h5>Pozostało środków</h5>
            <h2>{leftMoney} zł</h2>
        </div>
    );
}

export default LeftMoneySummaryChart;
import './SummaryCharts.css'
import CategoriesSummaryChart from "./CategoriesSummaryChart.jsx";
import LeftMoneySummaryChart from "./LeftMoneySummaryChart.jsx";
import IncomesChart from "./IncomesCharts.jsx";
import ExpensesChart from "./ExpensesChart.jsx";

function SummaryCharts({budgetPlanId, budgetPlanBaseId}) {
  return (
      <div className={'charts-grid-container'}>
          <div className={'summary-chart'}>
              <CategoriesSummaryChart budgetPlanId={budgetPlanId} budgetPlanBaseId={budgetPlanBaseId}/>
          </div>
          <div className={'left-money-summary-chart'}>
              <LeftMoneySummaryChart budgetPlanId={budgetPlanId} budgetPlanBaseId={budgetPlanBaseId}/>
          </div>
          <div className={'expenses-summary-chart'}>
              <IncomesChart budgetPlanId={budgetPlanId} budgetPlanBaseId={budgetPlanBaseId}/>
          </div>
          <div className={'incomes-summary-chart'}>
              <ExpensesChart budgetPlanId={budgetPlanId} budgetPlanBaseId={budgetPlanBaseId}/>
          </div>
      </div>
  );
}

export default SummaryCharts;
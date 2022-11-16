import {
  BrowserRouter as Router,
  Routes as Switch,
  Route,
} from "react-router-dom";
import { Login } from "./pages/Login";
import { Questionarios } from "./pages/Questionarios";

export const Routes = () => {
  return (
    <Router>
      <Switch>
        <Route path="/" element={<Questionarios />} />
        <Route path="/login" element={<Login />} />
      </Switch>
    </Router>
  );
};

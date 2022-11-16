import { Button, Paper, Typography } from "@mui/material";
import { Template } from "../components/Template";
import { IQuestionario } from "./Questionario";

const questionarios: IQuestionario[] = [
  {
    id: "1",
    descricao: "Avaliação do curso",
    vigente: true,
  },
  {
    id: "2",
    descricao: "Avaliação da infraestrutura",
    vigente: true,
  },
  {
    id: "3",
    descricao: "Avaliação dos docentes",
    vigente: false,
  },
];

export const Questionarios = () => {
  return (
    <Template>
      <Typography
        variant="h6"
        color="primary"
        component="div"
        sx={{ textAlign: "center" }}
      >
        Questionários
      </Typography>
      {questionarios.map((q) => (
        <QuestionarioItem key={q.id} questionario={q} />
      ))}
    </Template>
  );
};

interface IQuestionarioItem {
  questionario: IQuestionario;
}

const QuestionarioItem = ({ questionario }: IQuestionarioItem) => {
  return (
    <Paper
      sx={{
        padding: "1rem",
        marginTop: "1rem",
        display: "flex",
        flexDirection: "row",
        justifyContent: "space-between",
        alignItems: "center",
      }}
    >
      <Typography variant="body1" component="div">
        {questionario.descricao}
      </Typography>
      <Button variant="contained" disabled={!questionario.vigente}>
        Responder
      </Button>
    </Paper>
  );
};

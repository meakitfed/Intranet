﻿using System;
using System.Collections.Generic;

namespace IntranetPOPS1819.Models
{
    public interface IDal : IDisposable
    {
        // Collaborateurs
        Collaborateur ObtenirCollaborateur(int id);
        Collaborateur ObtenirCollaborateur(string idString);
        List<Collaborateur> ObtenirTousLesCollaborateurs();
        Collaborateur AjoutCollaborateur(string nom, string prenom, string mail, string mdp);

        // Services
        Service ObtenirServiceDeType(TypeService type);
        List<Service> ObtenirTousLesServices();
		Service AjoutService(string nom);
        void AssignerService(int idService, int idCollaborateur);

        // Missions
        Mission GetMission(int idMission);
        Mission AjoutMission(string nom, int serviceId);
		Mission AjoutMission(string nom);
        void AssignerMission(int idMission, int idCollaborateur);
        void ChangerStatut(int id, StatutMission statut);

        // Authentification
        Collaborateur Authentifier(string mail, string motDePasse);
		
        // Notes de frais
		void AjoutNoteDeFrais(int year, int idCollab, int month);
		void MiseAJourNotesDeFrais(string idString);
		void MiseAJourNotesDeFrais(int IdCollaborateur);
		void AjoutLigneDeFrais(int idCollab, int idNote, LigneDeFrais ligne);
        void EnvoiLigneDeFraisChefService(int idService, int idCollab, int idLigne);
        void ChangerStatutLigneDeFrais(int idLigne, StatutLigneDeFrais statut);

        // Congés
        void AjoutConge(int idCollab, Conge c);
        void ChangerStatut(int id, StatutConge s);                                      // Testé
        void EnvoiCongeChef(int idService, int idCollab, int idConge);
        void ValiderConge(int idCollab, int idConge);                                   // Testé
        void ModifierCongesRestant(int id, int jours);                                  // Testé

        // Notifications
        void AjoutNotif(int idCollab, Message m);

        // BD
		void InitializeBdd();
	}
}
